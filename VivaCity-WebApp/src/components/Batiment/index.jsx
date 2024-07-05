import React from 'react';
import './index.css';
import batiment1 from "../../assets/batiment1.avif";
import stone from "../../assets/batiments/stone.png";
import wood from "../../assets/batiments/wood.png";
import coin from "../../assets/batiments/coin.png";
import RessourcesItems from "../RessourcesItems/index.jsx";
import {updateBatiment} from "../../business/users.js";
import {getVillagesByUser} from "../../business/villages.js";
import useUsersSetter from "../../hooks/useUsersSetter.js";
import useVillagesSetter from "../../hooks/useVillagesSetter.js";
import { useLanguageContext } from '../../contexts/languageContext.jsx';
// Importez d'autres images de batiment si nécessaire

export default function Batiment({ batiment, village }) {
    const setUsers = useUsersSetter();
    const setVillages = useVillagesSetter();
    const { t } = useLanguageContext();
    let batimentImage;
    console.log(batiment)
    switch (batiment.picture) {
        case 'wood':
            batimentImage = wood;
            break;
        case 'coin':
            batimentImage = coin;
            break;
        case 'stone':
            batimentImage = stone;
            break;
        default:
            batimentImage = '';
            break;
    }

    async function _updateBatiment(){
        return await updateBatiment(batiment.id, localStorage.getItem("idUser"), village.id);
    }




    function update() {
        _updateBatiment().then(
            (u) => {
                setUsers(u);
                window.location.reload();

            }
        )

    }

    return (
        <div className="batiment-container">
            <div className="batiment-info">
                <h1>{batiment.name}</h1>
                <span>Level: {batiment.level}</span>


            </div>
            <img src={batimentImage} className="batiment-img" alt={batiment.name} />

            <span className="upgrade-button">
                <button onClick={update}>
                    <span className="upgrateBtn">
                        <div>{t('Upgrade')}</div>
                        <div><RessourcesItems cout={batiment.cout.nbr} picture={batiment.cout.ressource.ressourceItem.picture}></RessourcesItems></div>
                    </span>
                    </button>
            </span>
        </div>
    );
}

