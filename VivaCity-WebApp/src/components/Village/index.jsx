import React, {useEffect, useState} from 'react';
import village1 from "../../assets/village1.jpg";
import wood from "../../assets/ressources/wood.png";
import './index.css';
import './animation.css';
import Batiment from "../Batiment/index.jsx";
import Index from '../CreateVillage/index.jsx';
import Ressource from "../Ressource/index.jsx";
import { useLanguageContext } from '../../contexts/languageContext.jsx';

export default function Village({ village}) {


       const [isCreateMainVisible, setCreateMainVisible] = useState(false);
       const { t } = useLanguageContext();

    // Fonction pour changer l'état de la visibilité
    const toggleCreateMain = () => {
        setCreateMainVisible(!isCreateMainVisible);
    }

    
    return (
        <div className="village">
            <div className="village-container">
                <div className="village-info">
                    <h1>{village.name}</h1>
                    <span>{t('Level')}: {village.level}</span>
                </div>
                <div className="vil-bat">
                    <div className="ressource-container">
                        <img src={village1} className="village-img" />
                        <div className="res">
                            {village.ressources.map((ressource) => (
                                <Ressource key={ressource.id} ressource={ressource} />
                            ))}
                        </div>

                <span className="upgrade-button">
                    <button>
                        <span className="upgrateBtn">
                            <div> {t('Upgrade')} </div>
                        </span>
                    </button>
                </span>

                    </div>
                    <div className="bat">
                        {village.batiments.map((batiment) => (
                            <Batiment key={batiment.id} batiment={batiment} village={village} />
                        ))}

                    </div>
                </div>
            </div>
            <div className="formulaire">
                <div className="anim">
                    <h2 className="h2anim" data-text="VivaCity...">VivaCity...</h2>
                </div>

                  {!isCreateMainVisible && <span className="create-village">
                    <h1>{t('Do you want to create a new village?')}</h1>
                    <button onClick={toggleCreateMain} className="create-btn">{t('It\'s this way')}</button>
                </span>}

                {isCreateMainVisible && <Index village={village}></Index>}

            </div>
        </div>
    );
}




















