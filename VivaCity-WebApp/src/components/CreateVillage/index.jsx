import React, {useEffect, useState} from "react";
import "./index.css"
import {createVillage} from "../../business/users.js";
import { useLanguageContext } from '../../contexts/languageContext.jsx';

// eslint-disable-next-line react/prop-types
export default function Index({getVillages }){
    const [villageName, setVillageName] = useState('');
    const [villageImage, setVillageImage] = useState(null);
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

    const [villages, setVillages] = useState([]);

    const { t } = useLanguageContext();


    const handleNameChange = (e) => {
        setVillageName(e.target.value);
    };

    const handleImageChange = (e) => {
        setVillageImage(e.target.files[0]);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        if (!villageName) {
            setError("Merci d'entrer un nom de village");
            return;
        }

        console.log(villageName, localStorage.getItem('idUser'));

         await createVillage(villageName, localStorage.getItem('idUser'));


    };
    useEffect(() => {
        async function fetchVillages() {
            try {
                const villagesData = await getVillages();
                setVillages(villagesData);
            } catch (error) {
                console.error('Error fetching villages:', error);
            }
        }

        fetchVillages();
    }, [getVillages]);

    if (!villages || villages.length === 0) {
        return <p>Loading villages...</p>;
    }
    const handleSubmit2 = (e) =>{
        e.preventDefault();
        window.location.reload();
    }
    return (
        <div className="create-main" >
            <div className="village-list">
                {villages.map((village) => (
                    <div key={village.id} className="village-info" style={{paddingRight:'20px',marginLeft:'20px'}}>
                        <h1>{village.name}</h1>
                        <span>Level: {village.level}</span>
                    </div>))}
            </div>

            <form onSubmit={handleSubmit} className="form-create" id="uploadForm" encType="multipart/form-data">
                {error && <p style={{color: 'red'}}> {error}</p>}
                {success && <p style={{color: 'green'}}>{success}</p>}


                <div className="contain">
                    <div className="brand-logo"></div>
                    <div className="brand-title">VivaCity</div>
                    <div className="inputs">
                        <label className="cont-label">{t('Name of Village')}</label>
                        <input type="text" placeholder="Entrer le nom du village" required="true"
                               className="contain-input" onChange={handleNameChange}/>
                        <button className="cont-btn" type="submit" onClick={handleSubmit2}>{t('Send')}</button>
                    </div>

                </div>
            </form>

        </div>


    );


}