import { useState } from "react";

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
        <div className="create-main">
            <h2 className> Create a New Village</h2>
            <form onSubmit={handleSubmit}>
                {error && <p style={{ color : 'red'}}> {error}</p>}
                {success && <p style={{ color: 'green' }}>{success}</p>}


                <div>
                    <label htmlFor="villageName">Village Name:</label>
                    <input
                        type="text"
                        id="villageName"
                        placeholder="Saisir le nom du village"
                        value={villageName}
                        onChange={handleNameChange}
                        required
                    />
                </div>

                <div>
                    <label htmlFor="villageImage">Upload Image:</label>
                    <input
                        type="file"
                        id="villageImage"
                        onChange={handleImageChange}
                        required
                    />
                </div>

                <div>
                    <button type="submit">Create Village</button>
                </div>
            </form>
        </div>
    );
}