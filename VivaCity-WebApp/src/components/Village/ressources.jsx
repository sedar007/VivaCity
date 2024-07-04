import React from 'react';
import './index.css';
import wood1 from "../../assets/wood.png";
import wood2 from "../../assets/maison.png";

/** Mouammar soule
 * @param {Les ressources avec une image coorespondant} param0 
 * @returns 
 */
export default function Ressource({ressource}){
    let RessourceImage;

    console.log(ressource)

    switch (ressource.ressourceItem.picture) {
        case 'wood':
            RessourceImage = wood1;
            break;
        case 'maison':
            RessourceImage = wood2;
            break;
        default:
            RessourceImage = '';
            break;
    }
    return (
        
        <span className="ressource-info">
            <span>{ressource.ressourceItem.name}</span>
            <img src={RessourceImage} className="ressource-img" alt={ressource.ressourceItem.name} />
            <span>{ressource.nbr}/{ressource.max}</span>
        </span>
    );
}