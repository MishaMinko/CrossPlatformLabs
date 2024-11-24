import React, { useState } from 'react';
import LabForm from '../components/LabForm';
import LabResult from '../components/LabResult';
import axios from 'axios';

const LabsPage = () => {
    const [labViewModel, setLabViewModel] = useState({
        InputText: '',
        OutputText: ''
    });

    const handleLabSubmit = async (selectedLab, inputText) => {
        try {
            const response = await axios.post('/labs', {
                LabSelector: selectedLab,
                InputText: inputText
            });

            setLabViewModel({
                InputText: inputText,
                OutputText: response.data.OutputText || 'Результат не знайдено.'
            });
        } catch (error) {
            setLabViewModel({
                InputText: inputText,
                OutputText: 'Помилка: ' + error.message
            });
        }
    };

    return (
        <div className="container mt-5">
            <h1 className="mb-4 text-center">Варіант 62 - Фурсенко Михайло</h1>
            <LabForm onSubmit={handleLabSubmit} />
            <LabResult outputText={labViewModel.OutputText} />
        </div>
    );
};

export default LabsPage;
