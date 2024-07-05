import React, { useEffect, useRef } from 'react';

export default function AudioPlayer() {
    const audioRef = useRef(null);

    useEffect(() => {
        const audioElement = audioRef.current;

        // Jouer l'audio au chargement du composant
        if (audioElement) {
            audioElement.play();
        }

        // Arrêter l'audio après 1 minute
        const timeoutId = setTimeout(() => {
            console.log(audioElement);
            if (audioElement) {
                audioElement.pause();
            }
        }, 60000); // 60000ms = 1 minute @ A revoir Mouammar

        return () => {
            clearTimeout(timeoutId);
        };
    }, []);

    return (
        <audio ref={audioRef} src="/audio/stranger-things-124008.mp3" />
    );
}
