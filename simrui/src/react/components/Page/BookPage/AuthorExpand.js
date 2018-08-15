import React, { Component } from 'react';

class AuthorExpand extends Component {
    render() {
        return (
            <div>
                <div>{this.props.data.title}</div>
                <div>{this.props.data.pageCount}</div>
            </div>
        );
    }
}

export default AuthorExpand;