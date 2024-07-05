import React from 'react';
import '../Village/index.css';
import wood from "../../assets/ressources/wood.png";
import coin from "../../assets/ressources/coin.png";
import stone from "../../assets/ressources/stone.png";
import { useLanguageContext } from '../../contexts/languageContext';

export default function Ressource({ressource}){
    let RessourceImage;
    const { t } = useLanguageContext();

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
    };

    const ressourceColor = ressource.nbr >= ressource.max ? 'red':'blue'
    return (

        <span className="ressource-info">
            <span style={{color :'white', fontWeight :'bold'}}>{t(ressource.ressourceItem.name)}</span>
            <img src={RessourceImage} className="ressource-img" alt={ressource.ressourceItem.name} />
            <span style={{color : ressourceColor, fontWeight:'bold', fontSize :'1.5rem'}}>{ressource.nbr}/{ressource.max}</span>
        </span>
    );
}