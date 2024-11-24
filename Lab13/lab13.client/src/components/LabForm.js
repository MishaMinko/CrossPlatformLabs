import React, { useState } from 'react';

const LabForm = ({ onSubmit }) => {
    const [selectedLab, setSelectedLab] = useState('Lab1');
    const [inputText, setInputText] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        onSubmit(selectedLab, inputText);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="labSelector">Виберіть номер лаби</label>
                <select
                    id="labSelector"
                    name="LabSelector"
                    value={selectedLab}
                    onChange={(e) => setSelectedLab(e.target.value)}
                >
                    <option value="Lab1">Lab 1 - поєднання двох вказаних імен в одне, в якому є обидва імені</option>
                    <option value="Lab2">Lab 2 - сума елементів послідовності з вказаної кількості кроків</option>
                    <option value="Lab3">Lab 3 - алгоритм який як у грі Zuma за найкоротшу кількість кроків знищує усі букви</option>
                </select>
            </div>

            <div>
                <label htmlFor="inputText">Введіть дані</label>
                <textarea
                    id="inputText"
                    name="InputText"
                    value={inputText}
                    onChange={(e) => setInputText(e.target.value)}
                    rows="8"
                ></textarea>
            </div>

            <button type="submit">Виконати</button>
        </form>
    );
};

export default LabForm;
