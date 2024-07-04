import React from 'react';

import wood from "../../assets/ressources/wood.png";
import stone from "../../assets/ressources/stone.png";
import coin from "../../assets/ressources/coin.png";

import './index.css';

export default function RessourcesItems({ cout, picture }) {

    let css = "";
    function getPicture(picture) {
        switch (picture) {
            case 'wood':
                css = "wood"
                return wood;
            case 'stone':
                css = "stone"
                return stone;
            case 'coin':
                css = "coin"
                return coin;
            default:
                return '';
        }
    }



    return (
       <>
           <div className="ressourceItem-container">
         <span>{cout}</span>
           <img src={getPicture(picture)} className={css} alt={name} />
           </div>
       </>
);
}

