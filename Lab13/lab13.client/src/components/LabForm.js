import React, { useState, useEffect } from 'react';

const LabForm = ({ onSubmit, initialLab }) => {
    const [selectedLab, setSelectedLab] = useState(initialLab);
    const [inputText, setInputText] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        onSubmit(selectedLab, inputText);
    };

    useEffect(() => {
        setSelectedLab(initialLab);
    }, [initialLab]);

    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-3">
                <label htmlFor="labSelector" className="form-label">Виберіть номер лаби</label>
                <select
                    id="labSelector"
                    name="LabSelector"
                    className="form-select"
                    value={selectedLab}
                    onChange={(e) => setSelectedLab(e.target.value)}
                >
                    <option value="Lab1">Lab 1 - поєднання двох вказаних імен в одне, в якому є обидва імені</option>
                    <option value="Lab2">Lab 2 - сума елементів послідовності з вказаної кількості кроків</option>
                    <option value="Lab3">Lab 3 - алгоритм який як у грі Zuma за найкоротшу кількість кроків знищує усі букви</option>
                </select>
            </div>

            <div className="mb-3">
                <label htmlFor="inputText" className="form-label">Введіть дані</label>
                <textarea
                    id="inputText"
                    name="InputText"
                    className="form-control"
                    value={inputText}
                    onChange={(e) => setInputText(e.target.value)}
                    rows="8"
                ></textarea>
            </div>

            <button type="submit" className="btn btn-primary">Виконати</button>
        </form>
    );
};

export default LabForm;
