import React from 'react';

const LabResult = ({ outputText }) => {
    return (
        <div>
            <h4>Результат</h4>
            <textarea
                id="outputText"
                name="OutputText"
                rows="4"
                readOnly
                value={outputText}
            ></textarea>
        </div>
    );
};

export default LabResult;
