import { useState } from "react";
import "./createVillage.css"
export default function CreateVillage({onCreateVillage}){
    const [villageName, setVillageName] = useState('');
    const [villageImage, setVillageImage] = useState(null);
    const [error, setError] = useState(null);
    const [success, setSucces] = useState(null);

    const handleNameChange = (e) => {
        setVillageImage(e.target.value);
    };

    const handleImageChange = (e) =>{
        setVillageImage(e.taget.value);
    };

    const handleSubmit = (e) =>{
        e.preventDefault();
        if(!villageImage || !villageName){
            setError(" Merci d'entrer un nom du village et une image");
            return;
        }

        const newVilllage = {name : villageName, image : URL.createObjectURL(villageImage)};
        console.log(" village creée ", newVilllage);

        if(onCreateVillage){
            onCreateVillage(newVilllage);
        }

        setVillageImage(null);
        setVillageName('');
        setError(null);
        setSucces("Village created successfully !")
    };

    return (
        <div className="create-main" >

            <form onSubmit={handleSubmit} className="form-create">
                {error && <p style={{color: 'red'}}> {error}</p>}
                {success && <p style={{color: 'green'}}>{success}</p>}


                <div className="contain">
                    <div className="brand-logo"></div>
                    <div className="brand-title">VivaCity</div>
                    <div className="inputs">
                        <label className="cont-label">Nom d'Utilisateur</label>
                        <input type="text" placeholder="Entrer votre nom d'utilisateur" required="true" className="contain-input"/>
                        <label className="cont-label">Ajouter un fichier</label>
                        <input type="file"  required="true" className="contain-input"/>
                        <button className="cont-btn" type="submit">ENVOYER</button>
                    </div>

                </div>
            </form>
        </div>
    );
}