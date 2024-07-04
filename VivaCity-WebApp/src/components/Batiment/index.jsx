// eslint-disable-next-line no-unused-vars
import React from 'react';
import batimentPicture from "../../assets/maison.png";
import "./index.css"

// eslint-disable-next-line react/prop-types
export default function Batiment({ batiment}) {
    return (
        <div className="batiment-container">
            <div className="batiment-info">

                <h1>{batiment.name}</h1>
                <span>Level:{batiment.level}</span>

            </div>
            <img src={batimentPicture} className="batiment-img"/>
            <span className="upgrade-button">
                <button >Upgrade</button>
            </span>

        </div>
    )
}
