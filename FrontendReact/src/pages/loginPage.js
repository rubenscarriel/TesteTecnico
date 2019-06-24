import React from "react";
import TextField from "../components/text-field";
import PasswordField from "../components/password-field";
import LinkButton from "../components/link-button";
import CustomButton from "../components/custom-button";


class LoginPage extends React.Component {
    handleOnClick = () => {

    }

    render() {
        return(
            <div className="loginPage">
                <div className="mensagemTitulo">
                    Nova plataforma de <br />
                    cotação de apólices.
                </div>
                <div className="form">
                    <TextField />
                    <PasswordField />
                </div>
                <div className="rodape">
                    <LinkButton textLink="Esqueceu sua senha?" />
                    <CustomButton textButton="Entrar" />
                    <LinkButton textLink="Sou novo aqui" />
                </div>
            </div>
        );
    }
}

export default LoginPage;