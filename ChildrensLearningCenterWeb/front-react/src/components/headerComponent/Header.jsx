import React from 'react'
import './Header.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Routes, Route, useNavigate } from 'react-router-dom';

function Header() {
    const navigate = useNavigate();

    const childrenClick = (e) => {
        navigate("/Children")
    }

    const classesClick = (e) => {
        navigate("/Classes")
    }

    const directionsClick = (e) => {
        navigate("/Directions")
    }

    const specialistsClick = (e) => {
        navigate("/Specialists")
    }

    return (
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Navbar</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarColor01">
                        <ul class="navbar-nav me-auto">
                            <li class="nav-item">
                                <a class="nav-link active" href="#" onClick = {classesClick}>Classes
                                    <span class="visually-hidden">(current)</span>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#" onClick={childrenClick}>Children</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#" onClick={directionsClick}>Directions</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#" onClick={specialistsClick}>Specialists</a>
                            </li>
                        </ul>
                        <form class="d-flex">
                            <input class="form-control me-sm-2" type="text" placeholder="Search" />
                            <button class="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
                        </form>
                    </div>
                </div>
            </nav>
        </header>
    )
}

export default Header
