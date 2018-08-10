import React, { Component } from 'react';
import './Userinfo.css';
import './../../../css/btn.css'
import Username from './../Username/Username';

class Userinfo extends Component {
    render() {
        return (
            <div className="r-Username flex-item">
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
