import React, { Component } from 'react';
import './Userinfo.scss';
import Username from './../Username/Username';
import Userauth from './../Userauth/Userauth';
import Usersync from './../Usersync/Usersync';

class Userinfo extends Component {
    render() {
        return <div className="simr-r-Userinfo flex">
            <Username className="simr-flex-grow-2" />
            <div className="simr-flex-grow-1 simr-r-Userinfo-buttons">
                    <Userauth />
                    <Usersync />
                </div>
            </div>;
    }
}

export default Userinfo;
