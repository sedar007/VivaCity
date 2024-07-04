// // eslint-disable-next-line no-unused-vars
// import React from 'react';
// import batimentPicture from "../../assets/maison.png";
// import "./index.css"

// // eslint-disable-next-line react/prop-types
// export default function Batiment({ batiment}) {
//     return (
//         <div className="batiment-container">
//             <div className="batiment-info">

//                 <h1>{batiment.name}</h1>
//                 <span>Level:{batiment.level}</span>

//             </div>
//             <img src={batimentPicture} className="batiment-img"/>
//             <span className="upgrade-button">
//                 <button >Upgrade</button>
//             </span>

//         </div>
//     )
// }

import React from 'react';
import './index.css';
import batiment1 from "../../assets/batiment1.avif";
import batiment2 from "../../assets/batiment3.avif";
// Importez d'autres images de batiment si nécessaire

export default function Batiment({ batiment }) {
    let batimentImage;
    console.log(batiment)
    switch (batiment.picture) {
        case 'batiment1':
            batimentImage = batiment1;
            break;
        case 'batiment3':
            batimentImage = batiment2;
            break;
        default:
            batimentImage = '';
            break;
    }

    return (
        <div className="batiment-container">
            <div className="batiment-info">
                <h1>{batiment.name}</h1>
                <span>Level: {batiment.level}</span>
                <div className="batiment-cost">
                    <span>Cost: {batiment.cout.nbr} {batiment.cout.ressource.ressourceItem.name}</span>
                </div>
            </div>
            <img src={batimentImage} className="batiment-img" alt={batiment.name} />

            <span className="upgrade-button">
                <button>Upgrade</button>
            </span>
        </div>
    );
}

