import React from 'react';
import { Link } from 'react-router-dom';

const Layout = ({ children }) => {
    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div className="container-fluid">
                        <Link className="navbar-brand" to="/">Lab5</Link>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item">
                                    <Link className="nav-link text-dark" to="/">Home</Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link text-dark" to="/lab1">Lab 1</Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link text-dark" to="/lab2">Lab 2</Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link text-dark" to="/lab3">Lab 3</Link>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>
            <main role="main" className="container">
                {children}
            </main>
            <footer className="border-top footer text-muted">
                <div className="container">
                    &copy; 2024 - Lab5
                </div>
            </footer>
        </div>
    );
};

export default Layout;