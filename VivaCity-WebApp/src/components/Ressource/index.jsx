import React from 'react';
import '../Village/index.css';
import wood from "../../assets/ressources/wood.png";
import coin from "../../assets/ressources/coin.png";
import stone from "../../assets/ressources/stone.png";

export default function Ressource({ressource}){
    let RessourceImage;

    console.log(ressource)

    switch (ressource.ressourceItem.picture) {
        case 'wood':
            RessourceImage = wood;
            break;
        case 'coin':
            RessourceImage = coin;
            break;
        case 'stone':
            RessourceImage = stone;
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