import { Divider, MenuItem, TextField, Typography } from '@material-ui/core'
import React, { ChangeEvent, Fragment, useCallback } from 'react'
import { useDispatch } from 'react-redux'
import { useSelectedTheme } from '../../hooks'
import { Spacing } from '../../components'
import { setTheme } from '../../store/actions/Settings'

export default () => {
  const dispatch = useDispatch()
  const selectedTheme = useSelectedTheme()
  const onThemeChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value
    if (value === 'light' || value === 'dark' || value === 'system') {
      dispatch(setTheme(value))
    }
  }, [dispatch])

  return (
    <Fragment>
      <Typography
        variant="h6"
        component="h3"
      >
        Application
      </Typography>
      <Divider />
      <Spacing size={2} />
      <TextField
        label="Theme"
        defaultValue="system"
        variant="outlined"
        onChange={onThemeChange}
        value={selectedTheme}
        fullWidth
        select
      >
        <MenuItem value="system">System Default</MenuItem>
        <MenuItem value="light">Light</MenuItem>
        <MenuItem value="dark">Dark</MenuItem>
      </TextField>
    </Fragment>
  )
}
