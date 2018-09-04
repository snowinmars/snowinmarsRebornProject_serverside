import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import AuthorList from '../BookPage/AuthorList';
import BookExpand from '../BookPage/BookExpand';
var Config = require('Config');
var Lib = require('../../../Lib/componentUtils');
class AuthorsBooksTable extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInitByData: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.options = Config.bootstrapTableOptions;
    }

    componentDidMount() {
        var filtersBy;
        var url;
        if (this.props.authorId) {
            url = Config.apiurl.book.filter;
            filtersBy = { authorId: this.props.authorId };
        } else {
            url = Config.apiurl.author.filter;
            filtersBy = undefined;
        }

        Lib.fetchAndHandle({
            uri: url,
            data: {
                page: {
                    number: 0,
                    size: 1000
                },
                filtersBy: filtersBy
            },
            onSuccess: json => {
                this.setState({
                    response: JSON.parse(json),
                    isInitByData: true
                });
            },
            onError: this.onError
        });
    }

    onError = err =>
        this.setState({
            gotApiError: true,
            hasErrors: true,
            isInitByData: false
        });

    getDefaultData() {
        var defaultAuthor = {
            fullname: 'Loading...',
            birthDate: 'Loading...',
            deathDate: 'Loading...',
            key: 0
        };

        var data = [];

        for (var i = 0; i < 10; i++) {
            defaultAuthor.key = Math.random();
            data.push(defaultAuthor);
        }

        return data;
    }
    isExpandableRow = () => {
        return true;
    };

    expandComponent = row => {
        return <BookExpand row={row} />;
    };

    authorsFormatter = cell => {
        return <AuthorList authors={cell} />;
    };

    getAuthorTable(options) {
        const columns = [
            {
                dataField: 'title',
                text: 'Full name'
            }
        ];

        return (
            <BootstrapTable
                keyField="key"
                data={this.state.response.data}
                columns={columns}
            />
        );
    }

    getLoader() {
        var loaderClass =
            'simr-flex simr-flex-align-center simr-flex-justify-center';

        if (this.state.gotApiError) {
            loaderClass += ' simr-loader-api-error ';
        }

        if (this.state.isInitByData) {
            loaderClass += ' simr-loader hidden ';
        } else {
            loaderClass += ' simr-loader ';
        }

        const loader = (
            <div className={loaderClass}>
                <div className="sk-folding-cube">
                    <div className="sk-cube1 sk-cube" />
                    <div className="sk-cube2 sk-cube" />
                    <div className="sk-cube4 sk-cube" />
                    <div className="sk-cube3 sk-cube" />
                </div>
            </div>
        );
        return loader;
    }

    render() {
        const loader = this.getLoader();

        var table = null;
        if (this.state.isInitByData) {
                table = this.getAuthorTable(this.options);
            }
        

        return (
            <div>
                {loader}
                {table}
            </div>
        );
    }
}

export default AuthorsBooksTable;
