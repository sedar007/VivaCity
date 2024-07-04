import { useState } from "react";
import "./createVillage.css"

export default function CreateVillage({onCreateVillage}){
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

        // Vérifiez si le nom du village et l'image sont saisis
        if (!villageImage || !villageName) {
            setError("Merci d'entrer un nom de village et de choisir une image");
            return;
        }

        // Créez un objet FormData pour envoyer les données
        const formData = new FormData();
        formData.append('file', villageImage);
        console.log(villageImage);// Ajoutez le fichier à FormData

        try {
            const response = await fetch('http://localhost:5130/api/Upload/upload', {
                method: 'POST',
                body: formData,
            });

            if (!response.ok) {
                throw new Error('Failed to upload file');
            }

            // Si le téléchargement est réussi, réinitialisez les champs et affichez un message de succès
            setVillageImage(null);
            setVillageName('');
            setError(null);
            setSuccess("Village créé avec succès !");

            // Vous pouvez également appeler une fonction de rappel si nécessaire
            if (onCreateVillage) {
                onCreateVillage({ name: villageName, image: URL.createObjectURL(villageImage) });
            }

            console.log('File uploaded successfully');
        } catch (error) {
            console.error('Error uploading file:', error);
            setError('Erreur lors du téléchargement du fichier');
        }
    };


    return (
        <div className="create-main" >

            <form onSubmit={handleSubmit} className="form-create" id="uploadForm"  encType="multipart/form-data">
                {error && <p style={{color: 'red'}}> {error}</p>}
                {success && <p style={{color: 'green'}}>{success}</p>}


                <div className="contain">
                    <div className="brand-logo"></div>
                    <div className="brand-title">VivaCity</div>
                    <div className="inputs">
                        <label className="cont-label">Nom d'Utilisateur</label>
                        <input type="text" placeholder="Entrer votre nom d'utilisateur" required="true" className="contain-input" onChange={handleNameChange}/>
                        <label className="cont-label">Ajouter un fichier</label>
                        <input type="file"  required="true" className="contain-input" id="fileInput" onChange={handleImageChange}/>
                        <button className="cont-btn" type="submit">ENVOYER</button>
                    </div>

                </div>
            </form>

        </div>



    );



}