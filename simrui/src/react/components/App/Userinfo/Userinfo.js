import React, { PureComponent } from 'react';
import './Userinfo.scss';
import Username from './../Username/Username';
import Userauth from './../Userauth/Userauth';
import Usersync from './../Usersync/Usersync';

class Userinfo extends PureComponent {
    render() {
        return <div className="flex">
            <Username />
            <div className="simr-flex-grow-1 simr-r-Userinfo-buttons">
                    <Userauth />
                    <Usersync />
                </div>
            </div>;
    }
}

export default Userinfo;
