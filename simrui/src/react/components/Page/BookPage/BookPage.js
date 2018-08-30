import React, { PureComponent } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './BookPage.scss';
import AuthorList from './AuthorList';
import BookExpand from './BookExpand';
import { Link } from 'react-router-dom';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class BookPage extends PureComponent {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInitByFirstPage: false,
            isInitByAllData: false,
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
        Lib.fetchAndHandle({
            uri: Config.apiurl.book.filter,
            data: {
                page: {
                    number: 0,
                    size: 25
                }
            },
            onSuccess: json => {
                this.setState({
                    response: JSON.parse(json),
                    isInitByFirstPage: true
                });

                Lib.fetchAndHandle({
                    uri: Config.apiurl.book.filter,
                    data: {
                        page: {
                            number: 0,
                            size: 1000
                        }
                    },
                    onSuccess: json => {
                        this.setState({
                            response: JSON.parse(json),
                            isInitByAllData: true
                        });
                    },
                    onError: this.onError
                });
            },
            onError: this.onError
        });
    }

    onError = err =>
        this.setState({
            gotApiError: true,
            hasErrors: true,
            isInitByFirstPage: false,
            isInitByAllData: false
        });

    getActions() {
        return (
            <div className="simr-book-page-actions simr-flex simr-flex-justify-space-between">
                <span className="simr-btn">Add new book</span>

                <Link to={Config.url.author}>
                    <span className="simr-btn">All authors</span>
                </Link>
            </div>
        );
    }

    render() {
        var loader = this.getLoader();

        var actions = this.getActions();

        var table = this.getTable(this.options);

        return (
            <div>
                {loader}
                {actions}
                {table}
            </div>
        );
    }

    getDefaultData() {
        var defaultUser = {
            title: 'Loading...',
            authors: [
                {
                    name: {
                        givenName: 'Loading...',
                        fullMiddleName: 'Loading...',
                        familyName: 'Loading...',
                        key: 0
                    }
                }
            ],
            year: 'Loading...',
            imageUrl: 'Loading...',
            additionalInfo: 'Loading...',
            bookshelf: 'Loading...',
            flibustaUrl: 'Loading...',
            libRusEcUrl: 'Loading...',
            liveLibUrl: 'Loading...',
            owner: 'Loading...',
            pageCount: 'Loading...',
            key: 0
        };

        var data = [];

        for (var i = 0; i < 10; i++) {
            defaultUser.key = Math.random();
            defaultUser.authors[0].key = Math.random();
            data.push(defaultUser);
        }

        return data;
    }

    getRow = i => {
        return this.state.response.data[i.index];
    };

    isExpandableRow = row => {
        return true;
    };

    expandComponent = row => {
        return <BookExpand row={row} />;
    };

    authorsFormatter = cell => {
        return <AuthorList authors={cell} />;
    };

    getTable(options) {
        return (
            <BootstrapTable
                ref="table"
                data={this.state.response.data}
                striped
                hover
                search
                multiColumnSearch
                pagination
                expandableRow={this.isExpandableRow}
                expandComponent={this.expandComponent}
                options={options}
                searchPlaceholder="Search almost everywhere"
            >
                <TableHeaderColumn dataField="title" isKey dataSort searchable>
                    Title
                </TableHeaderColumn>

                <TableHeaderColumn
                    dataField="authors"
                    dataSort
                    searchable
                    dataFormat={this.authorsFormatter}
                    expandable={false}
                >
                    Authors
                </TableHeaderColumn>

                <TableHeaderColumn dataField="year" dataSort searchable>
                    Year
                </TableHeaderColumn>

                <TableHeaderColumn dataField="bookshelf" dataSort searchable>
                    Bookshelf
                </TableHeaderColumn>
            </BootstrapTable>
        );
    }

    getLoader() {
        var loaderClass =
            'simr-flex simr-flex-align-center simr-flex-justify-center';

        if (this.state.gotApiError) {
            loaderClass += ' simr-loader-api-error ';
        }

        if (this.state.isInitByFirstPage) {
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
}

export default BookPage;
