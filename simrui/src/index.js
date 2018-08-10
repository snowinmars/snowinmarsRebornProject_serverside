import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Title from './react/components/Title/Title';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Title />, document.getElementById('root'));
registerServiceWorker();
