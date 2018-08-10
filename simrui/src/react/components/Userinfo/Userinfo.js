import React, { Component } from 'react';
import './Userinfo.scss';
import './../../../css/btn.scss';
import Username from './../Username/Username';

class Userinfo extends Component {
    render() {
        return (
            <div className="r-Userinfo flex-item">
                <Username />
                <div className="r-Userinfo-buttons flex">
                    <span className="r-auth-btn btn">Logout</span>
                    <span className="r-sync">Sync</span>
                </div>
            </div>
        );
    }
}

export default Userinfo;
