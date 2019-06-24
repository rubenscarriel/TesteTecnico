import React from "react";

const PasswordField = () => {
    return (
        <div className="password-field">
            <label className="text-field__label">Senha</label>
            <input type="password" className="password-field__input" />
        </div>
    );
}

export default PasswordField;