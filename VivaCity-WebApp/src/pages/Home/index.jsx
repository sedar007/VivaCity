// import { useEffect, useState } from 'react';
// import {useLanguageContext} from "../../contexts/languageContext.jsx";

// export default function Home() {
// 	const { t } = useLanguageContext();
// 	return (
// 		<>
// 			<h1 className="text-3xl font-bold underline">
// 				Hello world!
// 				<div>{t("English")}</div>
// 				<div>{t("French")}</div>
// 			</h1>
// 		</>
// 	);
// }




// import {useEffect} from 'react';
// import {Link, useNavigate} from 'react-router-dom';

// export default function Home() {
//   const { t } = useLanguageContext();
//   const navigate = useNavigate();
  
//   useEffect(() => {
//     const token = localStorage.getItem('token');
//     if (!token) {
//       navigate('/login');
//     }
//   }, [navigate]);

//   return (
//   <div id="link">
//     <Link to="/login" className="link-button">Login</Link>
//   </div>
// )
//   ;
// }


import { useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';

export default function Home() {
    const navigate = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem('token');
        if (!token) {
            navigate('/login');
        }
    }, [navigate]);

    return (
        <div className="h-screen flex items-center justify-center">
            <Link 
                to="/login" 
                className="bg-blue-500 text-white py-2 px-4 rounded"
            >
                Start the Game
            </Link>
        </div>
    );
}
