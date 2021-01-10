import { makeStyles } from '@material-ui/core'
import React, { ReactNode } from 'react'

const useStyles = makeStyles(theme => ({
  grid: {
    display: 'grid',
    gap: theme.spacing(2),
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
    gridTemplateColumns: 'repeat(auto-fill, minmax(160px, 1fr))',
  },
  singleRow: {
    display: 'grid',
    gap: theme.spacing(2),
    marginTop: theme.spacing(),
    marginBottom: theme.spacing(2),
    flexDirection: 'column',
    overflowX: 'scroll',
    paddingBottom: theme.spacing(1),
    gridAutoColumns: 160,
    gridTemplateRows: '1fr',
    gridAutoFlow: 'column'
  }
}))

interface Props {
  children: ReactNode
  horizontal?: boolean
}

export default ({ children, horizontal }: Props) => {
  const classes = useStyles()

  return (
    <div className={horizontal ? classes.singleRow : classes.grid}>
      {children}
    </div>
  )
}
