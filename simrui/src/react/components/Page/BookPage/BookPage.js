import React, { PureComponent } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';

import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import './BookPage.scss';
import AuthorList from './AuthorList';
import BookExpand from './BookExpand';
import { Link } from 'react-router-dom';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');
const { SearchBar } = Search;
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

    expandColumnComponent = ({ expanded }) => {
        let content = expanded ? 'expand_more' : 'expand_less';

        return <i className="material-icons">{content}</i>;
    };

    getTable(options) {
        const columns = [
            {
                dataField: 'title',
                text: 'Title',
                sort: true
            },
            {
                dataField: 'authors',
                text: 'Authors',
                formatter: this.authorsFormatter,
                filterValue: authors => {
                    return authors.map(author => author.fullname);
                },
                sort: true
            },
            {
                dataField: 'year',
                text: 'Year',
                sort: true
            },
            {
                dataField: 'bookshelf',
                text: 'Bookshelf',
                sort: true
            },
            {
                dataField: 'additionalInfo',
                text: 'Hidden_additionalInfo',
                sort: true,
                hidden: true
            },
        ];

        return (
            <ToolkitProvider
                keyField="key"
                data={this.state.response.data}
                columns={columns}
                search
            >
                {props => (
                    <div>
                        <div className="simr-book-table-search">
                            <SearchBar {...props.searchProps} />
                        </div>
                        <BootstrapTable
                            hover
                            pagination={paginationFactory(this.options)}
                            expandRow={{
                                renderer: this.expandComponent,
                                showExpandColumn: true,
                                expandColumnRenderer: this
                                    .expandColumnComponent,
                                expandHeaderColumnRenderer: () => null
                            }}
                            {...props.baseProps}
                        />
                    </div>
                )}
            </ToolkitProvider>
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
}

export default BookPage;
