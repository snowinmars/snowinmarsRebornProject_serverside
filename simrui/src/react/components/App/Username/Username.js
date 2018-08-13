import React, { Component } from 'react';
import './Username.scss';

class Username extends Component {
    render() {
        return (
            <div className="r-Username btn">
                <span className="material-icons r-Username-avatar">
                    how_to_reg
                </span>
                <div>
                    <span>Snowinmars</span>
                </div>
            </div>
        );
    }
}

export default Username;
