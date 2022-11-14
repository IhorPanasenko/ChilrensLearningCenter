import React from 'react'

import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";

function ScalarFunction() {
    const requesstUrl = 'https://localhost:7296/api/Specialist/ScalarFunction'
    const [resp, setResp] = useState("");

    async function getData() {
        try {
            const response = await axios({
                method: "get",
                url: requesstUrl,
                data: JSON.stringify(),
                headers: { "Content-type": "apllication/json; charset=utf-8" }
            }).then((response) => {
                console.log(response.data);
                setResp(response.data);
            })

        } catch (err) {
            alert(err);
        }
    }

    return (
        <>
            <h1 className='pt-3'>Scalar Function</h1>
            <p>result Of executing scalar function: {resp}</p>
            <div className="buttonWrapper">
                <button type="button" class="btn btn-primary" onClick={getData}>Execute Scalar Function</button>
            </div>
        </>
    )
}

export default ScalarFunction
