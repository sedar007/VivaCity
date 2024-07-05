import {MemoryRouter} from "react-router-dom";
import {render, screen} from "@testing-library/react";

import {describe, expect, it} from 'vitest';

import React from "react";
import ViewNavItems from "./viewNavItems.jsx";

describe('ViewNavItems', () => {
    it('it renders', () => {

       render(
            <MemoryRouter>
                <ViewNavItems name="Games" />
            </MemoryRouter>
        );
        expect(
            screen.getAllByText(
                new RegExp('Games', 'i')
            )[0]
        ).toBeInTheDocument();
    });
});