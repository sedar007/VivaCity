import React, { useState, useEffect } from 'react';

// le temps de construction d'un batiment
export function startBuild(){
    const buildTime = level * 10;
    setTimeLeft(buildTime);
    setIsBuilding(true);
}


export default function BuildBatiment({ level, onBuildBatiment}){
    const [isBuilding, setIsBuilding] = useState(false);
    const [timeLeft, setTimeLeft] = useState(0);

    useEffect(() => {
        if (isBuilding && timeLeft > 0) {
            const timer = setInterval(() => {
                setTimeLeft(timeLeft - 1);
            }, 1000); // @ à Revoir Mouammar temps en seconde pour la construction et le temps d'attente
            return () => clearInterval(timer);
        } else if (isBuilding && timeLeft === 0) {
            setIsBuilding(false);
            onBuildBatiment();
        }
    }, [isBuilding, timeLeft]);

    return (
        <div>
            <h1 style={{color :'white', fontWeight:'bold',}} >Construction Niveau: {level}</h1>
            {isBuilding ? (
                <p>Temps restant: {timeLeft}s</p>
            ) : (
                <button style={{background:'blue', color :'white', fontWeight:'bold', width :'200px'}} onClick={startBuild}>Commencer la Construction</button>
            )}
        </div>
    );
};
