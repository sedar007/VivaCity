// import React, {useEffect, useState} from 'react';
// import village1 from "../../assets/village1.jpg";
// import wood from "../../assets/wood.png";
// import './index.css';
// import './animation.css';
// import Batiment from "../Batiment/index.jsx";
// import CreateVillage from './createVillage.jsx';
// import Ressource from "./ressources.jsx";


// export default function Village({ village}) {


//        const [isCreateMainVisible, setCreateMainVisible] = useState(false);

//     // Fonction pour changer l'état de la visibilité
//     const toggleCreateMain = () => {
//         setCreateMainVisible(!isCreateMainVisible);
//     }

    
//     return (
//         <div className="village">
//             <div className="village-container">
//                 <div className="village-info">
//                     <h1>{village.name}</h1>
//                     <span>Level: {village.level}</span>
//                 </div>
//                 <div className="vil-bat">
//                     <div className="ressource-container">
//                         <img src={village1} className="village-img" /> 
//                         <div className="res">
//                             {village.ressources.map((ressource) => (
//                                 <Ressource key={ressource.id} ressource={ressource} />
//                             ))}
//                         </div>
//                         <span className="upgrade-btn">
//                             <button>Upgrade</button>
//                         </span>
//                         <span className="create-village">
//                             <h1>Voulez-vous créer un nouveau village ?</h1>
//                             <button className="create-btn">C'est par ici</button>
//                         </span>
//                     </div>
//                     <div className="bat">
//                         {village.batiments.map((batiment) => (
//                             <Batiment key={batiment.id} batiment={batiment} />
//                         ))}

//                     </div>
//                 </div>
//             </div>
//             <div className="formulaire">
//                 <div className="anim">
//                     <h2 className="h2anim" data-text="VivaCity...">VivaCity...</h2>
//                 </div>

//                   {!isCreateMainVisible && <span className="create-village">
//                     <h1>Voulez vous Créer un nouveau village ?</h1>
//                     <button onClick={toggleCreateMain} className="create-btn">Cest par ici</button>
//                 </span>}

//                 {isCreateMainVisible && <CreateVillage></CreateVillage>}

//             </div>
//         </div>
//     );
// }


import React, { useState } from 'react';
import village1 from "../../assets/village1.jpg";
import './index.css';
import './animation.css';
import Batiment from "../Batiment/index.jsx";
import CreateVillage from './createVillage.jsx';
import Ressource from "./ressources.jsx";
import EvolutionRessources from '../EvolutionRessource/index.jsx';
import Entrepot from '../Entrepot/index.jsx';
import BuildBatiment from '../BuildBatiment/index.jsx';

export default function Village({ village }) {
    const [isCreateMainVisible, setCreateMainVisible] = useState(false);
    const [resources, setResources] = useState(village.ressources);

    // Fonction pour changer l'état de la visibilité
    const toggleCreateMain = () => {
        setCreateMainVisible(!isCreateMainVisible);
    }

    const handleBuildCompletion = () => {
        console.log('Construction terminée');
    }


    const handleUpgrade = () => {
        const updatedResources = resources.map((ressource) => {
            const newNbr = ressource.nbr + 5;
            return {
                ...ressource,
                nbr: newNbr >= ressource.max ? 0 : newNbr,
            };
        });
        setResources(updatedResources);
        console.log(setResources);
    };

    return (
        <div className="village">
            <div className="village-container">
                <div className="village-info">
                    <h1>{village.name}</h1>
                    <span>Level: {village.level}</span>
                </div>
                <div className="vil-bat">
                    <div className="ressource-container">
                        <img src={village1} className="village-img" />
                        <div className="res">
                            {village.ressources.map((ressource) => (
                                <Ressource key={ressource.id} ressource={ressource} />
                            ))}
                            <EvolutionRessources
                                initialRessources={{ wood: 0, coin: 0 }}
                                batiments={village.batiments}
                                villageLastUpdatedAt={village.updatedAt}
                            />
                        </div>
                        <span className="upgrade-btn">
                            <button style={{background :'blue', color:'white', fontWeight :'bold'}} onClick={handleUpgrade}>Upgrade</button>
                        </span>
                        <span className="create-village">
                            <h1>Voulez-vous créer un nouveau village ?</h1>
                            <button className="create-btn">C'est par ici</button>
                        </span>
                    </div>
                    <div className="bat">
                        {village.batiments.map((batiment) => (
                            <Batiment key={batiment.id} batiment={batiment} />
                        ))}
                        <BuildBatiment level={village.level} onBuildBatiment={handleBuildCompletion} />
                    </div>
                </div>
            </div>
            <Entrepot level={village.level} />
            <div className="formulaire">
                <div className="anim">
                    <h2 className="h2anim" data-text="VivaCity...">VivaCity...</h2>
                </div>

                {!isCreateMainVisible && <span className="create-village">
                    <h1>Voulez vous Créer un nouveau village ?</h1>
                    <button onClick={toggleCreateMain} className="create-btn">Cest par ici</button>
                </span>}

                {isCreateMainVisible && <CreateVillage />}
            </div>
        </div>
    );
}
