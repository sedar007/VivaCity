import React, { useState, useEffect } from 'react';
import { useLanguageContext } from "../../contexts/languageContext.jsx";

export default function EvolutionRessources({ initialRessources, batiments, villageLastUpdatedAt }) {
    const [ressources, setRessources] = useState(initialRessources);
    const { t } = useLanguageContext();

    //@ à verifier Mouammar => MAJ pour calculer les ressources sur lévolution 
    useEffect(() => {
        const updateRessources = () => {
            setRessources(prevRessources => {
                const updatedRessources = { ...prevRessources };
                
                const now = new Date();
                const timeElapsed = (now - new Date(villageLastUpdatedAt)) / 1000; // en secondes

                batiments.forEach(batiment => {
                    if (batiment.ressourceType === 'wood') {
                        updatedRessources.wood += Math.round(timeElapsed * batiment.level * 0.95);
                    } else if (batiment.ressourceType === 'coin') {
                        updatedRessources.coin += Math.round(timeElapsed * batiment.level * 0.95);
                    }
                });

                return updatedRessources;
            });
        };

        const interval = setInterval(updateRessources, 1000);
        return () => clearInterval(interval);
    }, [batiments, villageLastUpdatedAt]);

    return (
        <div>
            <h1 style={{background : 'gray', color:'white', fontWeight:'bold'}}>{t('Resources')}</h1>
            <p style={{background:'red', color :'white', fontWeight:'bold'}} >{t('Wood')}: {ressources.wood}</p>
            <p style={{background:'red', color :'white', fontWeight:'bold'}}>{t('Cash')}: {ressources.coin}</p>
        </div>
    );
};
