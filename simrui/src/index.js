import React from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import './../src/css/flex.scss';
import './../src/css/grid.scss';
import MainPage from './react/components/Page/MainPage/MainPage';
import registerServiceWorker from './registerServiceWorker';

if (process.env.NODE_ENV !== 'production') {
    const { whyDidYouUpdate } = require('why-did-you-update');
    whyDidYouUpdate(React);
}

ReactDOM.render(<MainPage />, document.getElementById('root'));
registerServiceWorker();
