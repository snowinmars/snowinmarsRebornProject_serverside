import React, { Component } from 'react';
import './Bot.scss';

class Bot extends Component {
    render() {
        return (
            <footer className={this.props.className + " simr-r-Bot"}>
                <span>GNU GPL</span>
            </footer>
        );
    }
}

export default Bot;
