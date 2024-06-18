import {Link} from "react-router-dom";

export default function Header(){
    return (
        <header>
            <div className="titre_project">VivaCity</div>
            <div className="content_pages">
                <Link to="/">Game</Link>
                <Link to="/classments"> classments</Link>
            </div>

            <div className="options">
                <Link to="/profiles">Users</Link>
                <button onClick={() => changeLanguage()}>Langue</button>
            </div>
        </header>
    )
}