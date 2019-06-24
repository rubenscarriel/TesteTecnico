import React from "react";

const CustomButton = ({textButton}) => {
    return (
        <div className="custom-button">
            <button className="custom-button_button">
                <span className="custom-button_title">{textButton}</span>
                <span className="custom-button_icon">
                    <i className="material-icons">
                        arrow_forward
                    </i>
                </span>
            </button>
        </div>
    );
}

export default CustomButton;