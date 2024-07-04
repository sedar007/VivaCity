// eslint-disable-next-line no-unused-vars
import React from 'react';
import village1 from "../../assets/village1.jpg";
import ressource1 from "../../assets/bois.png";
import wood from "../../assets/wood.png";
import './index.css'
import './animation.css'
import Batiment from "../Batiment/index.jsx";
import CreateVillage from "./createVillage.jsx";

// eslint-disable-next-line react/prop-types
export default function Village({ village}) {

    return (
        <div className="village">
            <div className="village-container">
                <div className="village-info">

                    <h1>{village.name}</h1>
                    <span>Level:{village.level}</span>

                </div>
                <div className="vil-bat">


                    <div className="ressource-container">

                        <img src={village1} className="village-img"/>


                        <div className="res">
                            {village.ressources.map((ressource) =>
                                <span className="ressource-info">

                                    <span>{ressource.ressourceItem.name}</span>
                                    <img src={ressource.ressourceItem.picture  == "wood" ? wood : ""} className="ressource-img"/>

                                </span>
                            )}


                        </div>
                        <span className="upgrate-btn">
                    <button>Upgrate</button>
                </span>
                        <span className="create-village">
                    <h1>Voulez vous Créer un nouveau village ?</h1>
                    <button className="create-btn">Cest par ici</button>
                </span>


                    </div>
                    <div className="bat">
                        {village.batiments.map((batiment) =>  <Batiment batiment ={batiment}/>)}
                    </div>
                </div>
            </div>
            <div className="formulaire">

                <div className="anim">
                    <h2 className="h2anim" data-text="VivaCity...">VivaCity...</h2>
                </div>
                <CreateVillage></CreateVillage>
            </div>

        </div>


    )
}
