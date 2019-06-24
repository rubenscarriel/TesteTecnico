import React from "react";

const LinkButton = ({textLink, onClick}) => {
    return (
        <div className="link-button">
            <button className="link-button__button" onClick={() => {onClick()}}>
                <span className="link-button__span">{textLink}</span>
            </button>
        </div>
    );
}

export default LinkButton;