import React, { useState, useEffect } from 'react';
import LabForm from '../components/LabForm';
import LabResult from '../components/LabResult';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const LabsPage = () => {
    const { labId } = useParams();
    const [labViewModel, setLabViewModel] = useState({
        InputText: '',
        OutputText: ''
    });

    const handleLabSubmit = async (selectedLab, inputText) => {
        console.log('Обрано лабораторну:', selectedLab);
        console.log('Введений текст:', inputText);

        try {
            const response = await axios.post('http://localhost:5145/Labs/Index', {
                LabSelector: selectedLab,
                InputText: inputText
            }, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            console.log('Відповідь від сервера:', response.data);

            setLabViewModel({
                InputText: inputText,
                OutputText: response.data.outputText || 'Результат не знайдено.'
            });

            console.log('Результат виконання:', response.data.outputText);
        } catch (error) {
            console.log('Помилка під час запиту:', error);

            setLabViewModel({
                InputText: inputText,
                OutputText: 'Помилка: ' + error.message
            });
        }
    };


    useEffect(() => {
        setLabViewModel({
            InputText: '',
            OutputText: ''
        });
    }, [labId]);


    return (
        <div className="container mt-2">
            <h1 className="mb-4 text-center">Варіант 62 - Фурсенко Михайло</h1>
            <LabForm onSubmit={handleLabSubmit} initialLab={labId} />
            <LabResult outputText={labViewModel.OutputText} />
        </div>
    );
};

export default LabsPage;
