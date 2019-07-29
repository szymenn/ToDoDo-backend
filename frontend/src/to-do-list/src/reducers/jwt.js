import { SET_JWT } from '../constants/actionTypes';

const jwt = (state = '', action) => {
    switch(action.type){
        case SET_JWT:
            return {
                jwt: action.jwt
            }
        default: 
            return state;
    }
}

export default jwt