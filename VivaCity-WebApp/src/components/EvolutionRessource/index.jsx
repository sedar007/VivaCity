import React, { useState, useEffect } from 'react';

export default function EvolutionRessources ({ initialRessources }){
    const [ressources, setRessources] = useState(initialRessources);

    useEffect(() => {
        const updateRessources = () => {
            setRessources(prevRessources => ({
                ...prevRessources,
                wood: prevRessources.wood + 1, // eventuelement à revoir @Mouammar
                coin: prevRessources.coin + 1,
            }));
        };

        const interval = setInterval(updateRessources, 1000); // eventuellement à revoir @Mouammar
        return () => clearInterval(interval);
    }, []);

    return (
        <div>
            <h1>Ressources</h1>
            <p>Bois: {ressources.wood}</p>
            <p>Monnaie: {ressources.coin}</p>
        </div>
    );
};
