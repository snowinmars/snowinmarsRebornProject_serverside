import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
var Config = require('Config');
var Lib = require('../../../Lib/componentUtils');

class AuthorsBooksTable extends Component {
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
        var filtersBy;
        if (this.props.author) {
            if (this.props.author.id) {
                console.log(this.props.authorId);
                filtersBy = { authorId: this.props.authorId };
            } else {
                console.log('all');
                filtersBy = undefined;
            }
        }

        Lib.fetchAndHandle({
            uri: Config.apiurl.author.filter,
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
                    isInitByFirstPage: true
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
            isInitByAllData: false,
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

    getTable(options) {
        return <BootstrapTable ref="table" data={this.state.response.data} striped hover pagination options={options}>
                <TableHeaderColumn dataField="fullname" isKey dataSort>
                    fullname
                </TableHeaderColumn>

                <TableHeaderColumn dataField="birthDate" dataSort>
                    birthDate
                </TableHeaderColumn>

                <TableHeaderColumn dataField="deathDate" dataSort>
                    deathDate
                </TableHeaderColumn>
            </BootstrapTable>;
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
        const loader = this.getLoader();

        const table = this.getTable(this.options);

        return <div>
                {loader}
                {table}
            </div>;
    }
}

export default AuthorsBooksTable;