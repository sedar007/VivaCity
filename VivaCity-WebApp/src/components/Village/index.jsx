// eslint-disable-next-line no-unused-vars
import React from 'react';
import { useState } from 'react';
import village1 from "../../assets/village1.jpg";
import ressource1 from "../../assets/bois.png";
import './index.css'
import './animation.css'
import Batiment from "../Batiment/index.jsx";
import CreateVillage from "./createVillage.jsx";

// eslint-disable-next-line react/prop-types
export default function Village({ name, level }) {
    const [isCreateMainVisible, setCreateMainVisible] = useState(false);

    // Fonction pour changer l'état de la visibilité
    const toggleCreateMain = () => {
        setCreateMainVisible(!isCreateMainVisible);
    }
    return (
        <div className="village">
            <div className="village-container">
                <div className="village-info">

                    <h1>{name}</h1>
                    <span>Level:{level}</span>

                </div>
                <div className="vil-bat">


                    <div className="ressource-container">

                        <img src={village1} className="village-img"/>

                        <div className="res-btn">
                            <div className="res">
                    <span className="ressource-info">

                        <span>Ressource 1 :</span>
                        <img src={ressource1} className="ressource-img"/>

                    </span>
                                <span className="ressource-info">

                        <span>Ressource 2 :</span>
                        <img src={ressource1} className="ressource-img"/>

                    </span>
                                <span className="ressource-info">

                        <span>Ressource 3 :</span>
                       <img src={ressource1} className="ressource-img"/>

                    </span>

                            </div>
                            <span className="upgrate-btn">
                    <button>Upgrate</button>
                </span>
                        </div>


                    </div>
                    <div className="bat">
                        <Batiment name="Hunterhouse" level=" 1"/>
                        <Batiment name="Hunterhouse" level=" 1"/>

                    </div>
                </div>
            </div>
            <div className="formulaire">
                <div className="anim">
                    <h2 className="h2anim" data-text="VivaCity...">VivaCity...</h2>
                </div>
                {!isCreateMainVisible && <span className="create-village">
                    <h1>Voulez vous Créer un nouveau village ?</h1>
                    <button onClick={toggleCreateMain} className="create-btn">Cest par ici</button>
                </span>}

                {isCreateMainVisible && <CreateVillage></CreateVillage>}

            </div>

        </div>


    )
}
