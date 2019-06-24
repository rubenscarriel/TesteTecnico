import React, { Fragment } from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";

import LoginPage from "./pages/loginPage";
import HomePage from "./pages/homePage";

class App extends React.Component {
    render() {
        return (
            <div className="container">
                <LoginPage />
            </div>
        )
    }
}

export default App;