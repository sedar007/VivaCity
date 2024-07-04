import React from 'react';

export function getMaxStorage ({level}){
    return 10 * level;
}

export default function Entrepot ({ level }){
    return (
        <div>
            <h1>Entrepôt Niveau: {level}</h1>
            <p>Capacité Maximale: {getMaxStorage(level)}</p>
        </div>
    );
}


