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
