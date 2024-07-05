import React, { useState } from "react";
import "./index.css"
import {createVillage} from "../../business/users.js";

export default function Index({village}){
    const [villageName, setVillageName] = useState('');
    const [villageImage, setVillageImage] = useState(null);
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

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


    return (
        <div className="create-main">
            <div className="village-info" style={{paddingBottom:'20px',marginBottom:'20px'}}>
                <h1>{village.name}</h1>
                <span>Level: {village.level}</span>
            </div>
            <form onSubmit={handleSubmit} className="form-create" id="uploadForm" encType="multipart/form-data">
                {error && <p style={{color: 'red'}}> {error}</p>}
                {success && <p style={{color: 'green'}}>{success}</p>}


                <div className="contain">
                    <div className="brand-logo"></div>
                    <div className="brand-title">VivaCity</div>
                    <div className="inputs">
                        <label className="cont-label">Nom du village</label>
                        <input type="text" placeholder="Entrer le nom du village" required="true"
                               className="contain-input" onChange={handleNameChange}/>
                        <button className="cont-btn" type="submit">ENVOYER</button>
                    </div>

                </div>
            </form>

        </div>


    );


}