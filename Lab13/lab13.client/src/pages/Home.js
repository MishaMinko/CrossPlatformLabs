import React from 'react';
import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="container text-center mt-2">
            <h1 className="display-4">Вітаємо!</h1>
            <hr className="my-5" />
            <h2 className="mb-4">Представлено 3 лаби</h2>

            <div className="row">
                <div className="col-md-4 mb-3">
                    <div className="card shadow-sm lab-card">
                        <div className="card-body">
                            <h5 className="card-title">Lab 1</h5>
                            <p className="card-text">
                                Поєднання двох вказаних імен в одне, в якому є обидва імені.
                            </p>
                            <Link to="/lab1" className="btn btn-primary">
                                Відкрити Lab 1
                            </Link>
                        </div>
                    </div>
                </div>
                <div className="col-md-4 mb-3">
                    <div className="card shadow-sm lab-card">
                        <div className="card-body">
                            <h5 className="card-title">Lab 2</h5>
                            <p className="card-text">
                                Сума елементів послідовності з вказаної кількості кроків.
                            </p>
                            <Link to="/lab2" className="btn btn-primary">
                                Відкрити Lab 2
                            </Link>
                        </div>
                    </div>
                </div>
                <div className="col-md-4 mb-3">
                    <div className="card shadow-sm lab-card">
                        <div className="card-body">
                            <h5 className="card-title">Lab 3</h5>
                            <p className="card-text">
                                Алгоритм, який, як у грі Zuma, за найкоротшу кількість кроків знищує усі букви.
                            </p>
                            <Link to="/lab3" className="btn btn-primary">
                                Відкрити Lab 3
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Home;
