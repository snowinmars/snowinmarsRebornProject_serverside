import React, { PureComponent } from 'react';
import { Link } from 'react-router-dom';

import List from '../../App/List/List';

const Config = require('Config');

class AuthorList extends PureComponent {
    renderAuthor() {
        return function(author) {
            return <Link to={Config.url.author + '?id=' + author.id} className="simr-author-item">
                        {author.name.givenName[0] +
                            '. ' +
                            author.name.fullMiddleName[0] +
                            '. ' +
                            author.name.familyName}
                </Link>;
        };
    }

    render() {
        if (this.props.authors) {
            return (
                <List
                    className="simr-author-list"
                    items={this.props.authors}
                    itemRender={this.renderAuthor()}
                />
            );
        }
    }
}

export default AuthorList;
