// eslint-disable-next-line no-unused-vars
import React from 'react';
import batiment from "../../assets/maison.png";
import "./index.css"

// eslint-disable-next-line react/prop-types
export default function Batiment({ name, level }) {
    return (
        <div className="batiment-container">
            <div className="batiment-info">

                <h1>{name}</h1>
                <span>Level:{level}</span>

            </div>

            <img src={batiment} className="batiment-img"/>
            <span className="upgrade-button">
                <button >Upgrade</button>
            </span>

        </div>
    )
}
