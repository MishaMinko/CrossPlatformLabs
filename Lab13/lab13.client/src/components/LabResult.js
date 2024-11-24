import React from 'react';

const LabResult = ({ outputText }) => {
    return (
        <div className="mt-4">
            <h4>Результат</h4>
            <textarea
                id="outputText"
                name="OutputText"
                className="form-control"
                rows="4"
                readOnly
                value={outputText}
            ></textarea>
        </div>
    );
};

export default LabResult;
